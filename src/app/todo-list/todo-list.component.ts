import { Component, OnInit } from '@angular/core';

class TodoItem{
  public name: string;
  public done: boolean;
  constructor(name: string){
    this.name = name;
    this.done = false;
  }
}

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  currentTodoItemName = '';
  todoItems: TodoItem[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  addTodoItem()
  {
    console.log(this.currentTodoItemName);
    this.todoItems.push(new TodoItem(this.currentTodoItemName));
    this.currentTodoItemName = '';
  }
  
}
