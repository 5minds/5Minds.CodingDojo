fun main(args: Array<String>) {
    var nodeA = Node("A")
    var nodeB = Node("B")
    var nodeC = Node("C")
    var nodeD = Node("D")
    var nodeE = Node("E")
    var nodeF = Node("F")
    var nodeG = Node("G")
    var nodeH = Node("H")

    nodeA.addNode(nodeB)
    nodeA.addNode(nodeC)
    nodeA.addNode(nodeD)
    nodeA.addNode(nodeE)

    nodeB.addNode(nodeA)
    nodeB.addNode(nodeC)
    nodeB.addNode(nodeD)
    nodeB.addNode(nodeE)

    nodeC.addNode(nodeA)
    nodeC.addNode(nodeB)
    nodeC.addNode(nodeD)
    nodeC.addNode(nodeG)

    nodeD.addNode(nodeA)
    nodeD.addNode(nodeB)
    nodeD.addNode(nodeC)
    nodeD.addNode(nodeH)

    nodeE.addNode(nodeA)
    nodeE.addNode(nodeB)
    nodeE.addNode(nodeF)
    nodeE.addNode(nodeG)

    nodeF.addNode(nodeE)
    nodeF.addNode(nodeG)

    nodeG.addNode(nodeC)
    nodeG.addNode(nodeE)
    nodeG.addNode(nodeF)
    nodeG.addNode(nodeH)

    nodeH.addNode(nodeD)
    nodeH.addNode(nodeG)

    var graph = Graph()

    graph.addNode(nodeA)
    graph.addNode(nodeB)
    graph.addNode(nodeC)
    graph.addNode(nodeD)
    graph.addNode(nodeE)
    graph.addNode(nodeF)
    graph.addNode(nodeG)
    graph.addNode(nodeH)

    println(message = graph.isEuler())

}