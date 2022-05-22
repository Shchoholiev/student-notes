import { User } from "./user.model";

export class Group {
    id: number = 0;
    name: string = "";
    inviteCode: string = "";
    users: User[];
}
