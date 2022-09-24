import {Component} from "@angular/core";
import {ClientService} from "../services/client.service";

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html'
})

export class LoginComponent {
  constructor(private clientService: ClientService) {
    clientService.getClients().subscribe(response => {
      console.log(response)
    });
  }
}
