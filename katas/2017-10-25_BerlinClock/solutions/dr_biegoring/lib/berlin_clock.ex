defmodule BerlinClock do
  @moduledoc """
  Documentation for BerlinClock.
  """

  def run([]) do
    run(DateTime.utc_now)
  end
  def run(%DateTime{hour: hour, minute: minute, second: second}) do
    run(hour, minute, second)
  end
  def run(argv) when is_list(argv) do
    [hour, minute, second] = Enum.map(argv, &String.to_integer/1)

    run(hour, minute, second)
  end
  def run(hour, minute, second) do
    {hour_modulo_5, hour_rest_5, minute_modulo_5, minute_rest_5, second_rest_2} =
      berlinify(hour, minute, second)

    IO.puts format(:second_rest_2, second_rest_2) |> yellow()
    IO.puts format(:hour_modulo_5, hour_modulo_5) |> red()
    IO.puts format(:hour_rest_5, hour_rest_5) |> red()
    IO.puts format(:minute_modulo_5, minute_modulo_5) |> make_x_red_and_pipe_yellow()
    IO.puts format(:minute_rest_5, minute_rest_5) |> yellow()
  end

  def berlinify(hour, minute, second) do
    {div(hour, 5), rem(hour, 5), div(minute, 5), rem(minute, 5), rem(second, 2)}
  end

  def format(:second_rest_2, 0), do: "          0          "
  def format(:second_rest_2, 1), do: "          1          "

  def format(:hour_modulo_5, 0), do: "                     "
  def format(:hour_modulo_5, 1), do: "====                 "
  def format(:hour_modulo_5, 2), do: "==== ====            "
  def format(:hour_modulo_5, 3), do: "==== ====   ====     "
  def format(:hour_modulo_5, 4), do: "==== ====   ==== ===="


  def format(:hour_rest_5, 0), do: "                     "
  def format(:hour_rest_5, 1), do: "====                 "
  def format(:hour_rest_5, 2), do: "==== ====            "
  def format(:hour_rest_5, 3), do: "==== ====   ====     "
  def format(:hour_rest_5, 4), do: "==== ====   ==== ===="

  def format(:minute_modulo_5,  0), do: "                     "
  def format(:minute_modulo_5,  1), do: "|                    "
  def format(:minute_modulo_5,  2), do: "| |                  "
  def format(:minute_modulo_5,  3), do: "| | X                "
  def format(:minute_modulo_5,  4), do: "| | X |              "
  def format(:minute_modulo_5,  5), do: "| | X | |            "
  def format(:minute_modulo_5,  6), do: "| | X | | X          "
  def format(:minute_modulo_5,  7), do: "| | X | | X |        "
  def format(:minute_modulo_5,  8), do: "| | X | | X | |      "
  def format(:minute_modulo_5,  9), do: "| | X | | X | | X    "
  def format(:minute_modulo_5, 10), do: "| | X | | X | | X |  "
  def format(:minute_modulo_5, 11), do: "| | X | | X | | X | |"

  def format(:minute_rest_5, 0), do: "                     "
  def format(:minute_rest_5, 1), do: "====                 "
  def format(:minute_rest_5, 2), do: "==== ====            "
  def format(:minute_rest_5, 3), do: "==== ====   ====     "
  def format(:minute_rest_5, 4), do: "==== ====   ==== ===="

  def format(_, _), do: "?"

  def yellow(string) do
    IO.ANSI.format_fragment([:yellow, string])
  end

  def red(string) do
    IO.ANSI.format_fragment([:red, string])
  end

  def make_x_red_and_pipe_yellow(string) do
    string
    |> String.split(" ")
    |> Enum.map(fn
        "|" -> yellow("|")
        "X" -> red("|")
        v -> v
      end)
    |> Enum.join(" ")
  end
end
