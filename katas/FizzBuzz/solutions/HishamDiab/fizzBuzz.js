let p = document.getElementById('outPut');
console.log(p.innerHTML)
fizzBuzz = () => {
    
    for(i=1; i < 100 ; i++){
        if(i % 3 == 0 & i % 5 == 0 || (i.toString().indexOf(3) > -1 & i.toString().indexOf(5) > -1 )){
            console.log('FizzBuzz')
         
         p.innerHTML += 'FizzBuzz<br/>'
         
        }
        else if(i % 5 == 0){
            console.log('Buzz')
            p.innerHTML += 'Buzz<br/>'
        }
        else if(i % 3 == 0 ){
            console.log('Fizz')
            p.innerHTML += 'Fizz<br/>'
            
        }
        else {
            console.log(i)
            p.innerHTML += i+'<br/>'
        }
    }

}

fizzBuzz()