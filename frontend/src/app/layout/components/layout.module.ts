import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MainLayoutComponent } from './main-layout.component';
import { SidebarComponent } from '../components/sidebar/sidebar.component';
import { HeaderComponent } from '../components/header/header.component';

import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    MainLayoutComponent, 
    SidebarComponent, 
    HeaderComponent],
  imports: [
    CommonModule, 
    RouterModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,    
  ],
  exports: [MainLayoutComponent]
})
export class LayoutModule {}
