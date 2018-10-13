document.getElementById("filepicker").addEventListener("change", function(event) {
  clearList();
  let doublicate = new Duplicate(event.target.files);
  const sel_mod = document.getElementById("sel_mod");
  const mod = sel_mod.options[sel_mod.selectedIndex].value;
  
  const sel_doublicate = document.getElementById("sel_doublicate");
  sel_doublicate.options.length = 0;
  sel_doublicate.innerHTML = "";
  
  const candidates = doublicate.getCandidates(mod);
  candidates.forEach((candidate, index) => {
    sel_doublicate.options[sel_doublicate.options.length] = new Option(candidate.name, index);
  });
  
  sel_doublicate.addEventListener("change", function () {
    clearList();
    checkDouplicate();
    async function checkDouplicate() {
      await doublicate.checkCandidate(candidates[sel_doublicate.options[sel_doublicate.selectedIndex].value]).then(res => {
        console.log(res);
        const ul_coublicate = document.getElementById("ul_doublicate");
        for (let key in res) {
          if (res.hasOwnProperty(key)) {
            let val = res[key];
            console.log("key", key);
            console.log("val", val);
            let li = document.createElement("li");
            let liText = "Filename: "+val[0].name+" located here:";
            val.forEach(item => {
              liText += ' "'+item.webkitRelativePath+'" ';
            });
            li.appendChild(document.createTextNode(liText));
            ul_coublicate.appendChild(li);
          }
        }
      });
    }
    //console.log(doublicate.checkCandidate(candidates[sel_doublicate.options[sel_doublicate.selectedIndex].value]));
  }, false);
  
  document.getElementById("filepicker").value = '';
}, false);

function clearList(){
  const ul_coublicate = document.getElementById("ul_doublicate");
  ul_coublicate.innerHTML = "";
}

