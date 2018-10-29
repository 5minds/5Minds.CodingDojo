namespace Doublette.Implementations
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    using Doublette.Contracts;

    public class Dublettenpruefung : IDublettenPruefung
    {
        public ICollection<IDublette> Pruefe_Kandidaten(ICollection<IDublette> kandidaten)
        {
            throw new NotImplementedException();
        }

        public ICollection<IDublette> Sammle_Kandidaten(string pfad)
        {
            return this.Sammle_Kandidaten(pfad, Vergleichsmodi.SizeAndName);
        }

        public ICollection<IDublette> Sammle_Kandidaten(string pfad, Vergleichsmodi modus)
        {
            ICollection<IDublette> result = new List<IDublette>();

            ICollection<AlleDateien> alleDateien = this.GetAlleDateienFake(pfad);

            if (modus == Vergleichsmodi.Size)
            {
                result = this.GetDublettenForSize(alleDateien);
            }
            else
            {
                result = this.GetDublettenForNameAndSize(alleDateien);
            }

            return result;
        }

        private ICollection<AlleDateien> GetAlleDateien(string path)
        {
            var applicationPath = AppDomain.CurrentDomain.BaseDirectory;
            var pathToPluginDir = Path.Combine(applicationPath, path);

            var alleDateien = Directory.GetFiles(pathToPluginDir);

            return new List<AlleDateien>();

        }

        private ICollection<AlleDateien> GetAlleDateienFake(string path)
        {
            var result = new List<AlleDateien>();
            result.Add (new AlleDateien 
            {
                Name = "Datei1",
                Pfad = "/Users/mba/source/5Minds.CodingDojo/katas/2018-02-21_Doubletten/solutions/biegomar/files/",
                Groesse = 500
            });

            result.Add (new AlleDateien 
            {
                Name = "Datei2",
                Pfad = "/Users/mba/source/5Minds.CodingDojo/katas/2018-02-21_Doubletten/solutions/biegomar/files/",
                Groesse = 500
            });

            result.Add (new AlleDateien 
            {
                Name = "Datei1",
                Pfad = "/Users/mba/source/5Minds.CodingDojo/katas/2018-02-21_Doubletten/solutions/biegomar/files/u1/",
                Groesse = 500
            });

            result.Add (new AlleDateien 
            {
                Name = "Datei3",
                Pfad = "/Users/mba/source/5Minds.CodingDojo/katas/2018-02-21_Doubletten/solutions/biegomar/files/u1/",
                Groesse = 400
            });

            return result;
        }

        private ICollection<IDublette> GetDublettenForNameAndSize(ICollection<AlleDateien> alleDateien)
        {
            var result = new List<IDublette>();
            var bucket = new Dictionary<string, IDublette>();

            foreach (var datei in alleDateien)
            {
                var key = datei.Name + datei.Groesse.ToString();
                if (bucket.ContainsKey(key))
                {
                    var dubletten = bucket[key];
                    (dubletten.Dateipfade as ICollection<string>).Add(datei.Pfad + datei.Name);
                }
                else
                {
                    var dubletten = new Dublette();
                    (dubletten.Dateipfade as ICollection<string>).Add(datei.Pfad + datei.Name);
                    bucket.Add(datei.Name + datei.Groesse.ToString(), dubletten);
                }
            }

            foreach (var item in bucket.Keys)
            {
                var dubletten = bucket[item];
                result.Add(dubletten);
            }

            return result;
        }

        private ICollection<IDublette> GetDublettenForSize(ICollection<AlleDateien> alleDateien)
        {
            var result = new List<IDublette>();
            var bucket = new Dictionary<string, IDublette>();

            foreach (var datei in alleDateien)
            {
                var key = datei.Groesse.ToString();
                if (bucket.ContainsKey(key))
                {
                    var dubletten = bucket[key];
                    (dubletten.Dateipfade as ICollection<string>).Add(datei.Pfad + datei.Name);
                }
                else
                {
                    var dubletten = new Dublette();
                    (dubletten.Dateipfade as ICollection<string>).Add(datei.Pfad + datei.Name);
                    bucket.Add(datei.Groesse.ToString(), dubletten);
                }
            }

            foreach (var item in bucket.Keys)
            {
                var dubletten = bucket[item];
                result.Add(dubletten);
            }

            return result;
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}