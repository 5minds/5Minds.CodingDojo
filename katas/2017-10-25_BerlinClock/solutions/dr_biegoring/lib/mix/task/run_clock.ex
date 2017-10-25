defmodule Mix.Tasks.RunClock do
  use Mix.Task

  @shortdoc  "Run the clock"
  @moduledoc @shortdoc

  @doc false
  def run(argv) do
    BerlinClock.run(argv)
  end
end
