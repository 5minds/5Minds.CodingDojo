defmodule NextBiggerNumber do
    def nextBigger(n) do                        
        result = next_bigger_rec(n+1, maxed_number(n))
        IO.puts  "#{n} ==> #{result}"
        result         
    end

    defp maxed_number(n) do
        Integer.digits(n) |> Enum.sort |> Enum.reverse |> Integer.undigits    
    end    

    defp next_bigger_rec(x, max) when x >= max do                
        if(max == maxed_number(x)) do                        
            x 
        else
            -1       
        end 
    end 
    
    defp next_bigger_rec(x, max) do        
        if(max == maxed_number(x)) do                        
            x
        else
            next_bigger_rec(x+1, max)
        end        
    end       
end
