import { CommonModule } from "@angular/common";
import { Component, OnDestroy, OnInit } from "@angular/core";
import { FormControl, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatSnackBarModule, MatSnackBar } from "@angular/material/snack-bar";
import { MatTableModule } from "@angular/material/table";
import { ActivatedRoute, Router, RouterModule } from "@angular/router";
import { Subscription, debounceTime, distinctUntilChanged } from "rxjs";
import { TasksService } from "../../tasks.service";
import { Task } from "../models/tasks";
import { MatToolbar, MatToolbarModule } from "@angular/material/toolbar";

@Component({
  selector: 'app-task-list',
  standalone: true,
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss'],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,


    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MatToolbarModule
  ]
})
export class TaskListComponent implements OnInit, OnDestroy {
  tasks: Task[] = [];
  loading = false;
  displayedColumns = ['title', 'description', 'isDone', 'lastUpdate', 'actions'];

  searchControl = new FormControl('');
  private sub = new Subscription();

  constructor(
    private taskService: TasksService,
    private route: ActivatedRoute,
    private router: Router,
    private snack: MatSnackBar
  ) {}

  ngOnInit(): void {
    const qpSub = this.route.queryParams.subscribe(params => {
      const search = params['search'] || '' || null;
      this.searchControl.setValue(search, { emitEvent: false });
      this.loadTasks(search);
    });
    this.sub.add(qpSub);

    const searchSub = this.searchControl.valueChanges
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe(value => {
        this.router.navigate([], {
          relativeTo: this.route,
          queryParams: { search: value || null },
          queryParamsHandling: 'merge'
        });
      });
    this.sub.add(searchSub);
  }

  loadTasks(search?: string  | null | undefined) {
    this.loading = true;
    this.taskService.getTasks(search).subscribe({
      next: (res) => { this.tasks = res; this.loading = false; },
      error: () => { this.loading = false; this.snack.open('Erro ao carregar tasks', 'OK', { duration: 3000 }); }
    });
  }

  deleteTask(t: Task) {
    if (!confirm(`Excluir task "${t.title}"?`)) return;
    this.taskService.deleteTask(t.id).subscribe({
      next: () => {
        this.snack.open('Task excluída', 'OK', { duration: 2000 });
        this.loadTasks(this.searchControl.value);
      },
      error: () => this.snack.open('Erro ao excluir', 'OK', { duration: 3000 })
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
