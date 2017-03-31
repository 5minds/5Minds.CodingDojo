defmodule Ameise.World do
  import Logger

  @world_width 15
  @world_height 15
  @movement [
    n: {0, -1},
    s: {0,  1},
    e: {-1, 0},
    w: {1, 0},
  ]
  @clockwise [
    n: :w,
    w: :s,
    s: :e,
    e: :n,
  ]
  @counter_clockwise [
    n: :e,
    e: :s,
    s: :w,
    w: :n,
  ]
  @black 1
  @white 0

  def start_link(opts \\ []) do
    {:ok, _pid} = GenServer.start_link(__MODULE__, opts, name: __MODULE__)
  end

  @doc "Moves the ameise according to the rules."
  def tick() do
    GenServer.call(__MODULE__, {:tick})
  end

  @doc "Returns the world tuple."
  def get() do
    GenServer.call(__MODULE__, {:get})
  end

  @doc "Returns the current step."
  def step() do
    {{_, _, _, ameise_step}, _} = get()

    ameise_step
  end

  @doc "Resets the world."
  def reset() do
    GenServer.call(__MODULE__, {:reset})
  end

  @doc "Returns a formatted CSV string representing the world."
  def to_csv({{ameise_x, ameise_y, ameise_direction, ameise_step}, world_list}) do
    for y <- 0..@world_height do
      row = Enum.at(world_list, y)
      for x <- 0..@world_width do
        value = Enum.at(row, x)

        if ameise_x == x and ameise_y == y do
          # show ameise!!!11
          csv_value(value, ameise_direction)
        else
          csv_value(value)
        end
      end
      |> Enum.join(",")
    end
    |> Enum.join("\n")
  end

  defp csv_value(@white), do: "w"
  defp csv_value(@black), do: "s"
  defp csv_value(@white, :n), do: "nw"
  defp csv_value(@black, :n), do: "ns"
  defp csv_value(@white, :e), do: "ow"
  defp csv_value(@black, :e), do: "os"
  defp csv_value(@white, :s), do: "sw"
  defp csv_value(@black, :s), do: "ss"
  defp csv_value(@white, :w), do: "ww"
  defp csv_value(@black, :w), do: "ws"

  # callbacks

  def init(_) do
    {:ok, init_state()}
  end

  defp init_state() do
    world_list =
      for y <- 0..@world_height do
        for x <- 0..@world_width do
          @white
        end
      end

    ameise_x = round(@world_width / 2)
    ameise_y = round(@world_height / 2)
    ameise_direction = :n
    ameise_step = 0

    {{ameise_x, ameise_y, ameise_direction, ameise_step}, world_list}
  end

  def handle_call({:tick}, _from, current_state) do
    current_state = move(current_state)

    {:reply, current_state, current_state}
  end

  def handle_call({:get}, _from, current_state) do
    {:reply, current_state, current_state}
  end

  def handle_call({:reset}, _from, _) do
    current_state = init_state()

    {:reply, current_state, current_state}
  end

  # Move the ameise!!!
  defp move({{ameise_x, ameise_y, ameise_direction, ameise_step}, world_list}) do
    ameise_step = ameise_step + 1

    {mod_x, mod_y} = @movement[ameise_direction]
    ameise_x = ameise_x + mod_x
    ameise_y = ameise_y + mod_y

    {ameise_direction, new_color} =
      case get_at(world_list, ameise_x, ameise_y) do
        @black ->
          {@counter_clockwise[ameise_direction], @white}
        @white ->
          {@clockwise[ameise_direction], @black}
      end

    world_list =
      set_at(world_list, ameise_x, ameise_y, new_color)

    {{ameise_x, ameise_y, ameise_direction, ameise_step}, world_list}
  end

  # Gets tile at position (`xx`, `yy`)
  defp get_at(world_list, x, y) do
    row = Enum.at(world_list, y)

    Enum.at(row, x)
  end

  # Sets tile at position (`xx`, `yy`)
  defp set_at(world_list, xx, yy, value) do
    for y <- 0..@world_height do
      row = Enum.at(world_list, y)
      for x <- 0..@world_width do
        orig_value = Enum.at(row, x)
        if x == xx and y == yy do
          value
        else
          orig_value
        end
      end
    end
  end
end
