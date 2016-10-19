defmodule NextBiggerNumberTest do
  use ExUnit.Case
  import NextBiggerNumber

  test "the truth" do
    assert nextBigger(12) == 21
    assert nextBigger(513) == 531
    assert nextBigger(2017) == 2071
    assert nextBigger(459853) == 483559
    assert nextBigger(9) == -1
    assert nextBigger(11) == -1
    assert nextBigger(531) == -1 
    #assert nextBigger(121111111111) == 211111111111 
  end
end
