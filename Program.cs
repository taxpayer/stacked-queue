// See https://aka.ms/new-console-template for more information
var stackedQueue = new StackedQueue<int>();

// TEST CASE 1
Console.WriteLine("TEST CASE 1");
Console.WriteLine("-----------");
stackedQueue.Enqueue(1);
stackedQueue.Enqueue(2);
stackedQueue.Enqueue(3);
Console.WriteLine(stackedQueue.Dequeue());
Console.WriteLine(stackedQueue.Dequeue());
Console.WriteLine(stackedQueue.Dequeue());
// END TEST CASE 1

Console.WriteLine();
Console.WriteLine();

// TEST CASE 2
Console.WriteLine("TEST CASE 2");
Console.WriteLine("-----------");
stackedQueue.Enqueue(1);
Console.WriteLine(stackedQueue.Dequeue());
stackedQueue.Enqueue(2);
Console.WriteLine(stackedQueue.Dequeue());
stackedQueue.Enqueue(3);
Console.WriteLine(stackedQueue.Dequeue());
// END TEST CASE 3

Console.WriteLine();
Console.WriteLine();

// TEST CASE 2
Console.WriteLine("TEST CASE 3");
Console.WriteLine("-----------");
Console.WriteLine(stackedQueue.Dequeue());
// END TEST CASE 3

Console.ReadLine();

class StackedQueue<T> {
	private bool isInStack1;
	private Stack<T> stack1 = new Stack<T>();
	private Stack<T> stack2 = new Stack<T>();

	public void Enqueue(T item) {
		if ((stack1.Count == 0) && (stack2.Count == 0)) {
			stack1.Push(item);
			isInStack1 = true;

			return;
		}

		if (isInStack1)
			stack2.Push(item);
		else
			stack2.Push(item);
	}

	public T Dequeue() {
		if ((stack1.Count == 0) && (stack2.Count == 0))
			return default(T);

		var inStack = isInStack1 ? stack1 : stack2;
		var outStack = isInStack1 ? stack2 : stack1;

		var result = inStack.Pop();

		for (var i = 0; i < outStack.Count - 1; i++) {
			var outItem = outStack.Pop();
			inStack.Push(outItem);
		}

		isInStack1 = !isInStack1;
		
		return result;
	}
}