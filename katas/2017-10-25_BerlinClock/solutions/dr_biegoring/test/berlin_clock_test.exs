defmodule BerlinClockTest do
  use ExUnit.Case
  doctest BerlinClock

  test "greets the world" do
    assert BerlinClock.berlinify(13, 56, 1) == {2, 3, 11, 1, 1}
    assert BerlinClock.berlinify(6, 6, 0) == {1, 1, 1, 1, 0}
    assert BerlinClock.berlinify(4, 4, 1) == {0, 4, 0, 4, 1}
  end
end
