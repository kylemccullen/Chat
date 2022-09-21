import { Component } from '@angular/core';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { Message } from 'src/models/message.model';
import { MessagesService } from 'src/services/messages.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  name: string = '';
  content: string = '';
  messages: Message[] = [];
  loading: boolean = true;

  connection = new HubConnectionBuilder()
    .withUrl('https://localhost:7265/hub/message')
    .build();

  constructor(private messagesService: MessagesService) {}

  ngOnInit() {
    this.messagesService.get().subscribe((messages: Message[]) => {
      this.messages = messages;
      this.loading = false;
    });

    this.connection
      .start()
      .then(() => console.log('Connection started'))
      .catch((err) => console.log('Error while starting connection: ' + err));

    this.connection.on('ReceiveMessage', (message: Message) => {
      this.messages.push(message);
    });
  }

  onSend() {
    let newMessage: Message = {
      name: this.name,
      content: this.content,
    };

    this.messagesService.post(newMessage).subscribe((message: Message) => {
      this.connection
        .invoke('SendMessage', message)
        .catch((err) => console.error(err));
    });

    this.content = '';
  }
}
