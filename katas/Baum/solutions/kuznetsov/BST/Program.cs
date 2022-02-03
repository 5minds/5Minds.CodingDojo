BST.BinarySearchTree tree = new BST.BinarySearchTree(new List<int> { 30,15,60,7,20,40,79,11});
string treeString = tree.printTree();
Console.WriteLine($"Tree sorted {treeString}");

Console.Write("input an element value to search (a valid integer value):");
string? valueStr = Console.ReadLine();
int value;
while(!int.TryParse(valueStr, out value) && !(valueStr??"").Trim().Equals("q"))
{
    Console.WriteLine();
    Console.Write("enter a valid integer value or q to abort: ");
    valueStr = Console.ReadLine();
}
if(valueStr == "q")
{
    Console.WriteLine("Press any key...");
    Console.ReadLine();
    return;
}
BST.BinaryTreeNode? node = tree.findNode(value);
if(node == null)
{
    Console.WriteLine("Node not found!");
    Console.WriteLine("Press any key...");
    Console.ReadLine();
    return;
}
Console.WriteLine($"Node found! {node}");
Console.WriteLine("Press any key...");
Console.ReadLine();
