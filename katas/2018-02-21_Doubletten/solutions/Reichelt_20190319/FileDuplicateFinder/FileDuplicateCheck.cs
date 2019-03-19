using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace FileDuplicateFinder
{
    public class FileDuplicateCheck : IDuplicateCheck
    {
        public IEnumerable<IDuplicate> FindCandidates(string searchPath)
        {
            return FindCandidates(searchPath, CompareModeEnum.FileSize);
        }

        public IEnumerable<IDuplicate> FindCandidates(string searchPath, CompareModeEnum compareMode)
        {
            // get all files for the duplicate check
            var fileList = GetFiles(new DirectoryInfo(searchPath));

            // filter for duplicate files
            var duplicateCandidates = GetDuplicateCandidates(fileList, compareMode);

            // check MD5 hash for all duplicate candidates
            var checkedCandidates = CheckCandidates(duplicateCandidates);

            return checkedCandidates;
        }

        /// <summary>
        /// Checks for all duplicate candidates the MDs hash and returns only identical files 
        /// </summary>
        /// <param name="candidates">The list of duplicate candidates</param>
        /// <returns>A list of MD5 hash identical duplicate files</returns>
        public IEnumerable<IDuplicate> CheckCandidates(IEnumerable<IDuplicate> candidates)
        {
            IEnumerable<FileDuplicate> checkedCandidates;

            using (var md5 = MD5.Create())
            {
                var fileDictionary = new Dictionary<FileInfo, string>();

                foreach (var duplicateCandidate in candidates)
                {
                    foreach (var fileName in duplicateCandidate.FilePaths)
                    {
                        // compute MD5 hash for every file and get string representation for grouping over this value
                        byte[] bytes = md5.ComputeHash(File.ReadAllBytes(fileName));
                        var hashValueString = BitConverter.ToString(bytes);

                        fileDictionary.Add(new FileInfo(fileName), hashValueString);
                    }
                }

                checkedCandidates = fileDictionary.GroupBy(r => r.Value).Where(group => group.Count() > 1).Select(
                    group => new FileDuplicate
                             {
                                 Files = group.Select(s => s.Key).ToList()
                             }
                );
            }

            return checkedCandidates;
        }

        /// <summary>
        /// Returns a list of files (FileInfo) of a directory and - if desired - including subdirectories = default 
        /// </summary>
        /// <param name="searchDirectory">The directory to search for duplicates</param>
        /// <param name="includeSubDirs">Optional: Include subdirectories in the duplicate search</param>
        /// <returns>A list of FileInfo objects of all duplicate candidates</returns>
        private static IEnumerable<FileInfo> GetFiles(DirectoryInfo searchDirectory, bool includeSubDirs = true)
        {
            // return null if directory not existing
            if (!Directory.Exists(searchDirectory.FullName))
            {
                throw new DirectoryNotFoundException();
            }

            var fileList = searchDirectory.GetFiles("*.*", includeSubDirs 
                ? SearchOption.AllDirectories 
                : SearchOption.TopDirectoryOnly);

            return fileList;
        }

        /// <summary>
        /// Returns a list of files (FileInfo) as duplicate candidates 
        /// </summary>
        /// <param name="fileList">A list of FileInfo objects for the duplicate search</param>
        /// <param name="compareMode">The compare mode for the duplicate search</param>
        /// <returns>A list of IDuplicate objects for the duplicate files</returns>
        private IEnumerable<FileDuplicate> GetDuplicateCandidates(IEnumerable<FileInfo> fileList, CompareModeEnum compareMode)
        {
            IEnumerable<FileDuplicate> resultList;

            switch (compareMode)
            {
                case CompareModeEnum.FileSize_FileName:
                default:
                    resultList = fileList.GroupBy(file => new { file.Name, file.Length })
                        .Where(group => group.Count() > 1)
                        .Select(group => new FileDuplicate
                                         {
                                             Files = group.ToList()
                                         }
                        );
                    break;
                   case CompareModeEnum.FileSize:
                       resultList = fileList.GroupBy(file => file.Length)
                           .Where(group => group.Count() > 1)
                           .Select(group => new FileDuplicate
                                            {
                                                Files = group.ToList()
                                            }
                           );
                    break;
            }

            return resultList;
        }
    }
}
