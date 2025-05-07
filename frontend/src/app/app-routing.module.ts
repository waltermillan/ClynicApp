import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { HomeComponent } from './features/home/home/home.component';
import { MainLayoutComponent } from './layout/components/main-layout.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: 'home', component: HomeComponent },

      // Lazy load clinic
      {
        path: 'clinic',
        loadChildren: () =>
          import('./features/clinic/clinic.module').then(m => m.ClinicModule)
      }
    ]
  },

  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}