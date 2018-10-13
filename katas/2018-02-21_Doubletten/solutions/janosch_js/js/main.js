document.getElementById("filepicker").addEventListener("change", function(event) {
  clearList();
  let dublicate = new Duplicate(event.target.files);
  const sel_mod = document.getElementById("sel_mod");
  const mod = sel_mod.options[sel_mod.selectedIndex].value;
  
  const sel_dublicate = document.getElementById("sel_dublicate");
  sel_dublicate.options.length = 0;
  sel_dublicate.innerHTML = "";
  
  const candidates = dublicate.getCandidates(mod);
  candidates.forEach((candidate, index) => {
    sel_dublicate.options[sel_dublicate.options.length] = new Option(candidate.name, index);
  });
  
  sel_dublicate.addEventListener("change", function () {
    clearList();
    checkDuplicate();
    async function checkDuplicate() {
      await dublicate.checkCandidate(candidates[sel_dublicate.options[sel_dublicate.selectedIndex].value]).then(res => {
        const ul_dublicate = document.getElementById("ul_dublicate");
        for (let key in res) {
          if (res.hasOwnProperty(key)) {
            let val = res[key];
            let li = document.createElement("li");
            let liText = "Filename: "+val[0].name+" located here:";
            val.forEach(item => {
              liText += ' "'+item.webkitRelativePath+'" ';
            });
            li.appendChild(document.createTextNode(liText));
            ul_dublicate.appendChild(li);
          }
        }
      });
    }
  }, false);
  
  document.getElementById("filepicker").value = '';
}, false);

function clearList(){
  const ul_coublicate = document.getElementById("ul_dublicate");
  ul_coublicate.innerHTML = "";
}

