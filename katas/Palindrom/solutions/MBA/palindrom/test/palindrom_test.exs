defmodule PalindromTest do
  use ExUnit.Case
  import Palindrom

  test "the truth" do
    assert recindrom("abba") == true
    assert recindrom("rentner") == true
    assert recindrom("Dienstmannamtsneid") == true
  end
end
