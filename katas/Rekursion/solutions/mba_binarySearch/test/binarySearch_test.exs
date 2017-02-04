defmodule BinarySearchTest do
  use ExUnit.Case
  import BinarySearch

  test "found!" do
    assert binarySearch([1,2,3,4,5,6,7,8,9], 2) == 1
    assert binarySearch([1,2,3,4,5,6,7,8,9], 5) == 4
    assert binarySearch([1,2,3,4,5,6,7,8,9], 1) == 0
    assert binarySearch([1,2,3,4,5,6,7,8,9], 9) == 8
  end

  test "not found!" do
    assert binarySearch([1,2,3,4,5,6,7,8,9], 12) == -1
    assert binarySearch([], 12) == -1
  end
end
