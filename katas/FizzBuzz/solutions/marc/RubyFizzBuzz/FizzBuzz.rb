class FizzBuzzCalculator
    def calc
        for value in 1..100 do
            puts naivImplementation(value)
        end
    end

    def naivImplementation(number)
        if number % 15 == 0      
            "FizzBuzz"
        elsif number % 5 == 0
            "Buzz"
        elsif number % 3 == 0
            "Fizz"
        else
            number.to_s
        end
    end

    def simpleImplementation(number)
        result = ""
        if number % 3 == 0
            result = "Fizz"
        end
        if number % 5 == 0
            result = result + "Buzz"
        end
        if result.empty?
            result = number.to_s
        end
        result
    end
end