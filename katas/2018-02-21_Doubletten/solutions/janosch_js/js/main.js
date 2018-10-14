const candidates = [];
const dublicate = {};

document.getElementById("filepicker").addEventListener("change", (event) => {
  //empty fields from previous searches
  clear();
  const sel_dublicate = document.getElementById("sel_dublicate");
  sel_dublicate.options.length = 0;
  sel_dublicate.innerHTML = "";
  
  //initiate library
  window.dublicate = new Duplicate(event.target.files);
  //read the selected search mod
  const mod = document.getElementById("sel_mod").options[document.getElementById("sel_mod").selectedIndex].value;
  
  //initiate the search for candidates
  window.candidates = window.dublicate.getCandidates(mod);
  //add options to the select for all identified candidates
  window.candidates.forEach((candidate, index) => {
    sel_dublicate.options[sel_dublicate.options.length] = new Option(candidate.name, index);
  });
  
  //enable the check button and reset the filepicker
  document.getElementById("btn_check").disabled = false;
  document.getElementById("filepicker").value = '';
}, false);

function checkCandidates() {
  //clear list of previous searches
  clear();
  const sel_dublicate = document.getElementById("sel_dublicate");
  
  //check if candidates are identified
  if (!sel_dublicate.options[sel_dublicate.selectedIndex]){
    alert("No doublicates identified at this folder, please chose another folder.");
  } else {
    checkDuplicate();
  }
  
  async function checkDuplicate() {
    //call the function that checks the md5 of the candidates
    await window.dublicate.checkCandidate(window.candidates[sel_dublicate.options[sel_dublicate.selectedIndex].value]).then(res => {
      //display all identified dublicates in a list with the path for each duplicate
      for (let key in res) {
        if (res.hasOwnProperty(key)) {
          let val = res[key];
          let li = document.createElement("li");
          let liText = "Filename: "+val[0].name+" located here:";
          val.forEach(item => {
            liText += ' "'+item.webkitRelativePath+'" ';
          });
          li.appendChild(document.createTextNode(liText));
          document.getElementById("ul_dublicate").appendChild(li);
        }
      }
    });
  }
}

function clear(){
  const ul_coublicate = document.getElementById("ul_dublicate");
  ul_coublicate.innerHTML = "";
}

