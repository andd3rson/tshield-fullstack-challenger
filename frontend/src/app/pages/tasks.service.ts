import { Injectable } from '@angular/core';
import { Task } from './tasks/models/tasks';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
 private baseUrl = 'http://localhost:7284/tasks'; // ajuste conforme seu backend

  constructor(private http: HttpClient) {}


  getTasks(search?: string | null): Observable<Task[]> {
    let params = new HttpParams();
    if (search) params = params.set('search', search);
    return this.http.get<Task[]>(this.baseUrl, { params });
  }

  getTask(id: number): Observable<Task> {
    return this.http.get<Task>(`${this.baseUrl}/${id}`);
  }


  createTask(payload: { title: string; description?: string; isDone: boolean }) {
    return this.http.post(this.baseUrl, payload);
  }


  updateTask(id: number, payload: { title: string; description?: string; isDone: boolean, id: number }) {
    console.log(id)
     console.log(payload)
    return this.http.put(`${this.baseUrl}/${id}`, payload);
  }

  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
