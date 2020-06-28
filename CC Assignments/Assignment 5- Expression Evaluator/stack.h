class node
{
	public:
		char data;
		node * next;
};

class LinkedList
{
public:
		node * head;
		LinkedList();
		~LinkedList();
		void insert(char v);
};

class Stack:public LinkedList
{
public:
	Stack();
	void push(char v);
	char pop();
};


class inode
{
	public:
		int data;
		inode * next;
};

class iLinkedList
{
public:
		inode * head;
		iLinkedList();
		~iLinkedList();
		void insert(int v);
};

class iStack:public iLinkedList
{
public:
	iStack();
	void push(int v);
	int pop();
};
