import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import { TasksService } from '../../tasks.service';

@Component({
  selector: 'app-task-form',
  standalone: true,
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.scss'],
  imports: [
    CommonModule,
  CommonModule,
  ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatCardModule,
    MatToolbarModule,
    MatIconModule,
    MatSnackBarModule
  ]
})
export class TaskFormComponent implements OnInit {
  form!: FormGroup;
  isEdit = false;
  taskId?: number;
  loading = false;

  constructor(
    private fb: FormBuilder,
    private taskService: TasksService,
    private route: ActivatedRoute,
    private router: Router,
    private snack: MatSnackBar
  ) {
   
  }

  buildForm() {

  }
  ngOnInit(): void {
   
    const id = this.route.snapshot.paramMap.get('id');
     this.form = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(200)]],
      description: [''],
      isDone: [false]
    });
    if (id) {
      this.isEdit = true;
      this.taskId = Number(id);
      this.loading = true;
      this.taskService.getTask(this.taskId).subscribe({
        next: (t) => {
          this.form.patchValue({
            title: t.title,
            description: t.description,
            isDone: t.isDone
          });
          this.loading = false;
        },
        error: () => {
          this.loading = false;
          this.snack.open('Erro ao carregar task', 'OK', { duration: 3000 });
        }
      });
    }
  }

  submit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const payload = this.form.value;
    payload.id = this.taskId;
    this.loading = true;
    if (this.isEdit && this.taskId != null) {
      this.taskService.updateTask(this.taskId, payload).subscribe({
        next: () => {
          this.snack.open('Task atualizada', 'OK', { duration: 2000 });
          this.loading = false;
          this.router.navigate(['/tasks']);
        },
        error: () => {
          this.snack.open('Erro ao atualizar', 'OK', { duration: 3000 });
          this.loading = false;
        }
      });
    } else {
      this.taskService.createTask(payload).subscribe({
        next: () => {
          this.snack.open('Task criada', 'OK', { duration: 2000 });
          this.loading = false;
          this.router.navigate(['/tasks']);
        },
        error: () => {
          this.snack.open('Erro ao criar', 'OK', { duration: 3000 });
          this.loading = false;
        }
      });
    }
  }

  cancel() {
    this.router.navigate(['/tasks']);
  }
}
