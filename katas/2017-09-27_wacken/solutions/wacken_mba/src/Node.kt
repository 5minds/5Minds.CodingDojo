class Node(name: String, var Adjaszenz: ArrayList<Node> = ArrayList()) {
    var Name: String = name

    fun addNode(node: Node) {
        Adjaszenz.add(node)
    }
}