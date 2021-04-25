//@QnSGeneratedCode
import { State } from '@app-contracts/modules/common/state';
import { Access } from '@app-contracts/persistence/account/access';
import { ActionLog } from '@app-contracts/persistence/account/action-log';
import { IdentityXRole } from '@app-contracts/persistence/account/identity-x-role';
import { LoginSession } from '@app-contracts/persistence/account/login-session';
import { User } from '@app-contracts/persistence/account/user';
/** CustomImportBegin **/
/** CustomImportEnd **/
export interface Identity
{
    id: number;
    guid: string;
    name: string;
    email: string;
    password: string;
    timeOutInMinutes: number;
    enableJwtAuth: boolean;
    accessFailedCount: number;
    state: State;
    accesss: Access[];
    actionLogs: ActionLog[];
    identityXRoles: IdentityXRole[];
    loginSessions: LoginSession[];
    users: User[];
/** CustomCodeBegin **/
/** CustomCodeEnd **/
}
