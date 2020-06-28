#include "stack.cpp"
#include<iostream>
#include <string.h>
using namespace std;
// submitted to: Dr Talha Waheed
// Submitted By: Komal Shehzadi 2016CS178
// Coversion of an infix expression into postfix and evaluation of postfix expression
int greaterorequalorless(char i, char j);
bool if_operator(char i);
int main()
{
  char myinput[20], read;
  char str[20];
  cout<< "--------------------------------------------"<< endl;
  cout<< "Enter an infix expression "<<endl;
  cin.getline(str, 20, '\n');
  Stack optr;
  char g;
  int i = 0, p = 0;
  char k = str[0];
  while (k != '\0')
  {
    if(k == '(')
    {
      optr.push(k);
    }
    else if(k == ')')
    {
      while(optr.head)
      {
        if(optr.head->data == '(')
        {
          optr.pop();
          break;
        }
        g = optr.pop();
        myinput[p] = g;
        p++;
        cout<< g;
      }
    }
    else if(!if_operator(k))
    {
      myinput[p] = k;
      p++;
      cout<< k;
    }
    else if(if_operator(k))
    {
      if(!optr.head)
      {
        optr.push(k);
      }
      else if(optr.head->data == '(')
      {
        optr.push(k);
      }
      else
      {
        while(optr.head && (greaterorequalorless(optr.head->data, k) == 1 || greaterorequalorless(optr.head->data, k) == 0 ))
        {
          g = optr.pop();
          cout<< g;
          myinput[p] = g;

          p++;
        }
        optr.push(k);
      }
    }
    ++i;
    k = str[i];
  }
  while(optr.head)
  {
    g = optr.pop();
    myinput[p] = g;
    cout<< g;
    p++;
  }
  myinput[p] = '\0';
  cout<< endl;






  iStack integerstack;
  Stack s1;
  int count = 0,l = 0;
  read = myinput[l];
  while(read)
  {
    if(!if_operator(read))
    {
      integerstack.push((int)read);
      s1.push(read);
      count++;
    }
    else
    {
      if(count >= 2)
      {
        int a, b;
        b = integerstack.pop() - 48;
        a = integerstack.pop() - 48;
        if(read == '+')
        {
          integerstack.push(a + b + 48);
          count--;
        }
        else if(read == '-')
        {
          integerstack.push(a - b + 48);
          count--;
        }
        else if(read == '*')
        {
          integerstack.push(a * b + 48);
          count--;
        }
        else if(read == '/')
        {
          integerstack.push(a / b + 48);
          count--;
        }
      }
      else
      {
        cout<< "less or invalid data in stack "<< endl;
        exit(0);
      }
    }
    l++;
    read = myinput[l];
  }
  cout<< integerstack.pop() - 48<< endl;
}
bool if_operator(char i)
{
  if(i == '+' || i == '-' || i == '*' || i == '/' || i == '%')
  {
    return true;
  }
  else
  {
    return false;
  }
}
int greaterorequalorless(char i, char j)
{
  if(i == '/' && j == '/')
  {
    return 0;
  }
  if(i == '/' && j == '*')
  {
    return 0;
  }
  if(i == '/' && j == '+')
  {
    return 1;
  }
  if(i == '/' && j == '-')
  {
    return 1;
  }
  if(i == '*' && j == '/')
  {
    return 0;
  }
  if(i == '*' && j == '*')
  {
    return 0;
  }
  if(i == '*' && j == '+')
  {
    return 1;
  }
  if(i == '*' && j == '-')
  {
    return 1;
  }
  if(i == '+' && j == '/')
  {
    return -1;
  }
  if(i == '+' && j == '*')
  {
    return -1;
  }
  if(i == '+' && j == '+')
  {
    return 0;
  }
  if(i == '+' && j == '-')
  {
    return 0;
  }
  if(i == '-' && j == '/')
  {
    return -1;
  }
  if(i == '-' && j == '*')
  {
    return -1;
  }
  if(i == '-' && j == '+')
  {
    return 0;
  }
  if(i == '-' && j == '-')
  {
    return 0;
  }
  return -1;
}
