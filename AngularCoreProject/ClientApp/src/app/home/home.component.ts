import {Component} from "@angular/core";
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})

export class HomeComponent {
  constructor(private router: Router) {
  }

  public Library = "Libreria pepito";

  public Navigate() {
    this.router.navigate(['/client'], {queryParams: {name: 'Juan', email: 'email@email.com'}});
  }
}
