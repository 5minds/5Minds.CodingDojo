import java.util.Collections.list

class Graph() {
    var nodes: ArrayList<Node> = ArrayList()

    fun addNode(node: Node){
        nodes.add(node)
    }

    fun isEuler(): Boolean {
        var found = true
        nodes.forEach { n ->
            run {
                println(n.Adjaszenz.size)
                found = found && (n.Adjaszenz.size % 2) == 0
                println((n.Adjaszenz.size % 2) == 0)
                println(found)
            }
        }
        return found
    }
}