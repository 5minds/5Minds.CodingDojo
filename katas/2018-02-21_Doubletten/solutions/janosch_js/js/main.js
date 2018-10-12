document.getElementById("filepicker").addEventListener("change", function(event) {
  let doublicate = new Duplicate(event.target.files);
  console.log(doublicate.getCandidates("name"));
  
}, false);