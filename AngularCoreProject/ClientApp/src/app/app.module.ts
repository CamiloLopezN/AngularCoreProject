import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import {AppComponent} from './app.component';
import {HomeComponent} from "./home/home.component";
import {LoginComponent} from "./login/login.component";
import {ProductComponent} from "./products/product.component";
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {ClientComponent} from './client/client.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClientComponent,
    LoginComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'client', component: ClientComponent},
      {path: 'login', component: LoginComponent},
      {path: 'products', component: ProductComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
