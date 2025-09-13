import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskFormComponent } from './task-form/task-form.component';

const routes: Routes = [
  { path: 'tasks', component: TaskListComponent },               // lista com query param 'search'
  { path: 'tasks/new', component: TaskFormComponent },           // criação
  { path: 'tasks/:id/edit', component: TaskFormComponent },      // edição
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TasksRoutingModule { }
