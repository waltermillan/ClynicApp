// Systems components
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  provideHttpClient,
  withInterceptorsFromDi,
  withFetch,
} from '@angular/common/http';
import { MatDialogModule } from '@angular/material/dialog';
import { DatePipe } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';


// Users components
import { LoginComponent } from '@features/auth/login/login.component';
import { HomeModule } from './features/home/home.module'; // Asegúrate de importar HomeModule
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { SuccessDialogComponent } from '@shared/components/modals/success-dialog/success-dialog.component';
import { FailureDialogComponent } from '@shared/components/modals/failure-dialog/failure-dialog.component';
import { WarningDialogComponent } from '@shared/components/modals/warning-dialog/warning-dialog.component';
import { ConfirmDialogComponent } from '@shared/components/modals/confirm-dialog/confirm-dialog.component';
import { LayoutModule } from './layout/components/layout.module';

@NgModule({
  declarations: [
    AppComponent,
    SuccessDialogComponent,
    FailureDialogComponent,
    WarningDialogComponent,
    ConfirmDialogComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MatDialogModule,
    CommonModule,
    LayoutModule,
    HomeModule
  ],
  providers: [
    DatePipe,
    provideHttpClient(withInterceptorsFromDi(), withFetch()),
    provideAnimationsAsync(),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
