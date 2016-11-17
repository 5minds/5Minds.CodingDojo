defmodule Palindrom do
    def recindrom(wort) do
        if String.length(wort) <= 1 do
            true
        else
            String.upcase(String.first(wort)) == String.upcase(String.last(wort)) and recindrom(String.slice(wort, 1..String.length(wort)-2))
        end
    end
end
