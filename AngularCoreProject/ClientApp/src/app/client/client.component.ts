import {Component, Input} from "@angular/core";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-client-component',
  templateUrl: './client.component.html'
})

export class ClientComponent {

  //@Input() name: string;
  //@Input() email: string;

  nameQueryString: string | undefined;
  emailQueryString: string | undefined;

  constructor(private route: ActivatedRoute) {
    this.route.queryParams.subscribe(param => {
      this.nameQueryString = param['name'];
      this.emailQueryString = param['email'];
    });
  }

  createClient() {

  }
}
