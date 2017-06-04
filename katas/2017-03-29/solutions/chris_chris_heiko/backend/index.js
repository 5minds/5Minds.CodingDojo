var express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');

var app = express()
app.use(bodyParser.json())
app.use(cors());

app.post('/langton', bodyParser.json(), (req, res) => {
  res.send(nextStep(req.body))
});

app.listen(8000, function () {
  console.log('app listening on port 8000!')
});

function nextStep(currentStep) {
  const field = currentStep.field;
  const ant = currentStep.ant;
  const currentField = field[ant.y][ant.x];
  const fieldWidth = field[0].length;
  const fieldHeight = field.length;

  field[ant.y][ant.x] = !currentField;
  if (currentField === true) {
    ant.direction--;
  } else {
    ant.direction++;
  }

  if (ant.direction === -1) {
    ant.direction = 3;
  } else if (ant.direction === 4) {
    ant.direction = 0;
  }
  
  if (ant.direction === 0) {
    ant.y--;
  } else if (ant.direction === 1) {
    ant.x++;
  } else if (ant.direction === 2) {
    ant.y++;
  } else if (ant.direction === 3) {
    ant.x--;
  }

  if (ant.x < 0) {
    ant.x = 0;
  } else if (ant.x >= fieldWidth) {
    ant.x = fieldWidth - 1;
  }

  if (ant.y < 0) {
    ant.y = 0;
  } else if (ant.y >= fieldHeight) {
    ant.y = fieldHeight - 1;
  }

  return {
    field: field,
    ant: ant,
  };
}