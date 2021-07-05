import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

class TodoItem{
  public id: number;
  public name: string;
  public done: boolean;

  constructor(name: string){
    this.id = 0;
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

  private _http: HttpClient;

  constructor(http: HttpClient) { 
    this._http = http;
  }

  async ngOnInit() {
    this.todoItems =  await this._http.get<TodoItem[]>('/api/todo').toPromise();
  }

  async addTodoItem()
  {
    let newTodo: TodoItem = new TodoItem(this.currentTodoItemName);
    let newTodoId: number = await this._http.post<number>("/api/todo", newTodo).toPromise();
    newTodo.id = newTodoId;
    
    this.todoItems.push(new TodoItem(this.currentTodoItemName));
    this.currentTodoItemName = '';
  }
  
  async updateTodoItem(todo: TodoItem){
    await this._http.put(`/api/todo/${todo.id}`, todo).toPromise();
  }
}
