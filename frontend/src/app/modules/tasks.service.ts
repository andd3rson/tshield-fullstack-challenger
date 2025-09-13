import { Injectable } from '@angular/core';
import { Task } from './tasks/models/tasks';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
 private baseUrl = '/api/tasks'; // ajuste conforme seu backend

  constructor(private http: HttpClient) {}

  // Lista com filtro opcional; usa query param "search" como pedido
  getTasks(search?: string): Observable<Task[]> {
    let params = new HttpParams();
    if (search) params = params.set('search', search);
    return this.http.get<Task[]>(this.baseUrl, { params });
  }

  getTask(id: number): Observable<Task> {
    return this.http.get<Task>(`${this.baseUrl}/${id}`);
  }

  // Ao criar, não enviamos id nem lastUpdate (backend deve preencher)
  createTask(payload: { title: string; description?: string; isDone: boolean }): Observable<Task> {
    return this.http.post<Task>(this.baseUrl, payload);
  }

  // Ao atualizar, enviamos somente os campos editáveis (backend pode atualizar lastUpdate)
  updateTask(id: number, payload: { title: string; description?: string; isDone: boolean }): Observable<Task> {
    return this.http.put<Task>(`${this.baseUrl}/${id}`, payload);
  }

  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
