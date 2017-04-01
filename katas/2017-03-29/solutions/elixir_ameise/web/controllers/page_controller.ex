defmodule Ameise.PageController do
  use Ameise.Web, :controller

  def index(conn, _params) do
    result = Ameise.World.tick
    csv = Ameise.World.to_csv(result)

    render conn, "index.html", [csv: csv]
  end

  def reset(conn, _) do
    Ameise.World.reset
    redirect(conn, to: "/?reset=1")
  end
end
