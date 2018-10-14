class Duplicate {
  //expecting a filelist object (for instance taken from <input type="file"> in the constructor
  constructor(fileList){
    this.fileList = fileList;
  }
  
  //filtering the candidates from the filelist. By default candidates will be filtered by name and size, if the mod parameter is provided with 'name', candidates will be filtered only by name
  getCandidates(mod = 'name+size'){
    
    const candidates = [];
    //create an array with only filenames
    const fileNameArray = Array.from(this.fileList).map(file => file.name);
    
    //generate an object for each dublicated filename and their index in the array
    let canObj = {};
    for (let i = 0; i < fileNameArray.length; i++) {
      if(canObj.hasOwnProperty(fileNameArray[i])) {
        canObj[fileNameArray[i]].push(i);
      } else if (fileNameArray.lastIndexOf(fileNameArray[i]) !== i) {
        canObj[fileNameArray[i]] = [i];
      }
    }
    //create an object for better readability
    for (let key in canObj) {
      let files = [];
      canObj[key].forEach(pos => {
        files.push(this.fileList[pos]);
      });
      candidates.push({
        name: key,
        files: files
      });
    }
    
    //check dandidates by name and size
    if (mod === "name+size"){
      let newCandidates = [];
      candidates.forEach(can => {
        //get all size values
        const sizes = Array.from(can["files"]).map(file => file.size);
        const uniqueSizes = sizes.filter((size, index) => {
          return sizes.indexOf(size) === index;
        });
        
        //filter all different size values and check if multiple of same different size
        uniqueSizes.forEach(size => {
          const newFiles = can["files"].filter((file) => {
            return file.size === size;
          });
          if (newFiles.length > 1){
            newCandidates.push({
              name: can.name,
              files: newFiles
            });
          }
        });
      });
      return newCandidates;
    }
    return candidates;
    
  }
  
  //check candidates by md5
  async checkCandidate(candidate){
    //create the md5 value for all candidates as promises
    function createMd5FromFiles() {
      const fileReaders = [];
      for (let i = 0; i < candidate.files.length; ++i) {
        const file = candidate.files[i];
        fileReaders.push(new Promise(function (resolve, reject) {
          const fileReader = new FileReader;
          fileReader.onload = () => {
            const hash = CryptoJS.MD5(CryptoJS.enc.Latin1.parse(fileReader.result));
            const md5 = hash.toString(CryptoJS.enc.Hex);
            const md5file = {
              file: candidate.files[i],
              md5: md5
            };
            resolve(md5file);
          };
      
          fileReader.readAsBinaryString(file);
        }))
      }
      //return when all promises are resolved
      return Promise.all(fileReaders);
    }
    
    const md5s = await createMd5FromFiles();
    
    //create the return value as a json with the md5 as key and all files with that md5 in an array as value
    function filterDuplicates(candidates) {
      const dublicates = {};
      for (let i=0; i < candidates.length; i++){
        if(!dublicates[candidates[i].md5]){
          dublicates[candidates[i].md5] = [candidates[i].file];
        } else {
          dublicates[candidates[i].md5].push(candidates[i].file);
        }
      }
      return dublicates;
    }
    //return the generated json
    return await filterDuplicates(md5s);
  }
}