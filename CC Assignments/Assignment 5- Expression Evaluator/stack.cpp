#include "stack.h"
#include <iostream>
using namespace std;
LinkedList::LinkedList()
{
	head = NULL;
}
void LinkedList::insert(char v)
{
	node * n = new node();
	n->data = v;
	n->next = NULL;
	if(this->head == NULL)
	{
		this->head = n;
	}
  else
  {
    n->next = this->head;
		this->head = n;
  }
}
Stack::Stack()
{
	this->head = NULL;
}
void Stack::push(char v)
{
	insert(v);
}
char Stack::pop()
{
  char temp = '\0';
  if(head == NULL || head->next == NULL)
	{
    if(head == NULL)
    {
      head = NULL;
      return temp;
    }
		if(head->next == NULL)
		{
			temp = head->data;
			head = NULL;
			return temp;
		}
	}
	else
	{
		temp = head->data;
		head = head->next;
		return temp;
	}
}

LinkedList::~LinkedList()
{
  delete head;
}



iLinkedList::iLinkedList()
{
	head = NULL;
}
void iLinkedList::insert(int v)
{
	inode * n = new inode();
	n->data = v;
	n->next = NULL;
	if(this->head == NULL)
	{
		this->head = n;
	}
  else
  {
    n->next = this->head;
		this->head = n;
  }
}
iStack::iStack()
{
	this->head = NULL;
}
void iStack::push(int v)
{
	insert(v);
}
int iStack::pop()
{
  int temp = -1;
  if(head == NULL || head->next == NULL)
	{
    if(head == NULL)
    {
      head = NULL;
      return temp;
    }
		if(head->next == NULL)
		{
			temp = head->data;
			head = NULL;
			return temp;
		}
	}
	else
	{
		temp = head->data;
		head = head->next;
		return temp;
	}
}

iLinkedList::~iLinkedList()
{
  delete head;
}
