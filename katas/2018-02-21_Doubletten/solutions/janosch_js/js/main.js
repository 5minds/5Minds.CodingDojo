document.getElementById("filepicker").addEventListener("change", function(event) {
  let doublicate = new Duplicate(event.target.files);
  let sel_mod = document.getElementById("sel_mod");
  const mod = sel_mod.options[sel_mod.selectedIndex].value;
  console.log(doublicate.getCandidates(mod));
  
  document.getElementById("filepicker").value = '';
}, false);