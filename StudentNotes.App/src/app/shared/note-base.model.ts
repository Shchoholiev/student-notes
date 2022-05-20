import { Type } from "./type.model";
import { Subject } from "./subject.model";
import { User } from "./user.model";

export class NoteBase {
    id: number = 0;
    type: Type = new Type();
    deadLine: Date = new Date();
    subject: Subject = new Subject();
    author: User = new User();
    usersCompleted: User[] = [];
}
