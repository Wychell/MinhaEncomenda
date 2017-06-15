import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FormsModule } from '@angular/forms';
import { TimelineComponent } from './components/timeline/timeline.component';
import { Ng2MapModule } from 'ng2-map';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { ToastyModule } from 'ng2-toasty';
import { NgLoadingBarModule } from 'ng-loading-bar';
import { ApiServico } from "./servicos/api.servico"


@NgModule({
    imports: [
        UniversalModule,// Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: '**', redirectTo: 'home' }
        ])
        ,
        Ng2MapModule.forRoot({
            apiUrl: 'https://maps.google.com/maps/api/js?key=AIzaSyCeg-_7gXgVNj65phHF948ZhKYsUbTaTB0'
        }),
        ToastyModule.forRoot(),
        NgLoadingBarModule.forRoot(),
    ],
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        TimelineComponent
    ],
    providers: [ApiServico]
})
export class AppModule {
}



