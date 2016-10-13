var nextBigger = (number) => {
	
	// zahl in ein ziffern-array umwandeln
	const digits = String(number).split('').map(digit => parseInt(digit));
	switchIndex = -1;
	
	// Von rechts nach links die ziffern durchgehen, und bei jeder ziffer prüfen,
	// ob es rechts davon eine größere ziffer gibt. Wenn ja, die beiden ziffern tauschen
	for (let i = digits.length - 2; i >= 0; i--)
	{
		for (let j = digits.length - 1; j > i; j--)
		{
			if (digits[j] <= digits[i]) {
				continue;
			}
			
			// Es wurde eine Ziffer gefunden, die rechts von sich eine größere ziffer hat
			// Die beiden tauschen
			digits[j] = digits.splice(i, 1, digits[j])[0];
			switchIndex = i;
			break;
		}
		
		// Falls einmal getauscht wurde, ist das größer machen der Zahl abgeschlossen
		if (switchIndex >= 0) {
			break;
		}
	}
	
	// Wenn ziffern getauscht wurden, versuchen die zahl, welche aus den Ziffern rechts von der tauschstelle besteht
	// so klein wie möglich zu machen. Dazu die ziffern rechts von der Tauschstelle aufsteigens sortieren
	if (switchIndex >= 0) {
	
		// Ersetzt die zahlen rechts von der Tauschstelle mit ihrer sortierten darstellung
		Array.prototype.splice.apply(digits, [switchIndex + 1, digits.length - (switchIndex + 1)].concat(digits.slice(switchIndex + 1).sort()))
		return parseInt(digits.join(''));
	}
	
	// Wenn nicht getauscht wurde, gabs keine größere Ziffer. -1 zurückgeben
	return -1;
}

const cases = [12, 513, 2017, 459853, 9, 111, 531];

cases.forEach((testNumber) => {
  const result = nextBigger(testNumber);
  console.log(`Testing ${testNumber} => ${result}`);
});