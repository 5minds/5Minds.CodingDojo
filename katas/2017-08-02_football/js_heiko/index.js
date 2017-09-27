const canvas = document.getElementById('field');
const context = canvas.getContext('2d');
const textfield = document.getElementById('field_text');
const resultSpan = document.getElementById('result');

const fieldWidth = 60;
const fieldHeight = 45;
const scaleFactor = 10;
const width = fieldWidth * scaleFactor + 1;
const height = fieldHeight * scaleFactor;
const canvasWidth = width * window.devicePixelRatio;
const canvasHeight = height * window.devicePixelRatio;
const elementSize = scaleFactor * devicePixelRatio;
canvas.style.cssText = `width: ${width}px; height: ${height}px`;
canvas.width = canvasWidth;
canvas.height = canvasHeight;

function hasNeighbour(playerArray, x, y) {
  for (let i = 0; i < playerArray.length; i++) {
    if (Math.abs(x - playerArray[i][0]) < 2 && Math.abs(y - playerArray[i][1]) < 2) {
      return true;
    }
  }

  return false;
}

function drawField(input) {
  let x = 0;
  let y = 0;
  for (let i = 0; i < input.length; i++) {
    if (x >= fieldWidth) {
      x = 0;
      y+= 1;
    }

    if (input[i] === '|') {
      if (x === 0 || x === fieldWidth - 1) {
        context.fillStyle = "black";
      } else {
        continue;
      }
    } else if (input[i] === 'x') {
      context.fillStyle= 'blue';
    } else if (input[i] === '+') {
      context.fillStyle = 'red';
    } else if (input[i] === '@') {
      context.fillStyle = 'white'
    } else if (input[i] === 'o') {
      context.fillStyle="green";
    } else {
      continue;
    }

    context.fillRect(x * elementSize, y * elementSize, elementSize, elementSize);
    x++
  }

  context.fillStyle="white";
  context.fillRect(canvasWidth/2, 0, 1, canvasHeight);
}

function calculateOffside(input) {
  let defenderCount = 0;
  let attackerCount = 0;
  let ballSeen = false;
  let abseits = false;

  const defender = [];
  const attacker = [];

  input = input.replace(/\n/g, '');
  input = input.replace(/o\|o/g, 'oo');

  for (let x = fieldWidth; x > 0; x--) {
    for (let y = 0; y < fieldHeight; y++) {
      let charIndex = x + y * fieldWidth - 1;

      if (input[charIndex] === 'x') {
        if (!hasNeighbour(defender, x, y)) {
          defenderCount++;
        }
        defender.push([x, y]);
      } else if (input[charIndex] === '+') {
        if (!hasNeighbour(attacker, x, y)) {
          attackerCount++;
        }
        attacker.push([x, y])
      } else if (input[charIndex] === '@') {
        ballSeen = true;
      }
    }

    if (ballSeen == false && defenderCount < 2 && attackerCount > 0) {
      abseits = true;
      break;
    }
  }

  if (abseits) {
    resultSpan.innerText = "Abseits";
  } else if (attackerCount === 0 && defenderCount === 0) {
    result.innerText = "Trainingssituation";
  } else {
    result.innerText = "kein Abseits";
  }
}

textfield.addEventListener('input', () => {
  drawField(textfield.value);
  calculateOffside(textfield.value);
});

context.fillStyle = "green";
context.fillRect(0, 0, canvasWidth, canvasHeight);
context.fillStyle="white";
context.fillRect(canvasWidth/2, 0, 1, canvasHeight);
