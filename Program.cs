using System;

namespace StackeQueue {
	internal class Program {
		static void Main(string[] args) {
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
			// END TEST CASE 2

			Console.WriteLine();
			Console.WriteLine();

			// TEST CASE 3
			Console.WriteLine("TEST CASE 3");
			Console.WriteLine("-----------");
			Console.WriteLine(stackedQueue.Dequeue());
			// END TEST CASE 3


			Console.WriteLine();
			Console.WriteLine();

			// TEST CASE 4
			Console.WriteLine("TEST CASE 4");
			Console.WriteLine("-----------");
			stackedQueue.Enqueue(1);
			stackedQueue.Enqueue(2);
			Console.WriteLine(stackedQueue.Dequeue());
			stackedQueue.Enqueue(3);
			stackedQueue.Enqueue(4);
			Console.WriteLine(stackedQueue.Dequeue());
			Console.WriteLine(stackedQueue.Dequeue());
			stackedQueue.Enqueue(5);
			Console.WriteLine(stackedQueue.Dequeue());
			Console.WriteLine(stackedQueue.Dequeue());
			// END TEST CASE 4

			Console.ReadLine();
		}
	}
}

class StackedQueue<T> {
	private Stack<T> stack1 = new Stack<T>();
	private Stack<T> stack2 = new Stack<T>();

	public void Enqueue(T item) {
		if (stack1.Count == 0)
			stack1.Push(item);
		else
			stack2.Push(item);
	}

	public T Dequeue() {
		if ((stack1.Count == 0) && (stack2.Count == 0))
			return default(T);

		var result = stack1.Pop();

		if (stack1.Count == 0) {
			var stack2Count = stack2.Count;

			for (var i = 0; i < stack2Count; i++) {
				var outItem = stack2.Pop();
				stack1.Push(outItem);
			}
		}

		return result;
	}
}