import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { FilmsTableComponent } from './components/filmstable/filmstable.component';

@NgModule({
    declarations: [
        AppComponent,
        FilmsTableComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'films', pathMatch: 'full' },
            { path: 'films', component: FilmsTableComponent },
            { path: '**', redirectTo: 'films' }
        ])
    ]
})
export class AppModuleShared {
}
