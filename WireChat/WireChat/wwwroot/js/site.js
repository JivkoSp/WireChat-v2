// Get the current DateTimeOffset string
function getCurrentDateTimeOffset() {
    const now = new Date();
    const offset = -now.getTimezoneOffset();
    const offsetHours = Math.floor(Math.abs(offset) / 60);
    const offsetMinutes = Math.abs(offset) % 60;
    const offsetSign = offset >= 0 ? '+' : '-';
    const pad = (num) => num.toString().padStart(2, '0');

    const formattedOffset = `${offsetSign}${pad(offsetHours)}:${pad(offsetMinutes)}`;
    const dateTimeOffset = `${now.toISOString().split('.')[0]}${formattedOffset}`;

    return dateTimeOffset;
}

function createChatMessage(messageDto, currentUserName) {

    let liElement = '';

    if (messageDto && messageDto.userName == currentUserName) {

        liElement = `<li class="chat-right d-flex mb-4">
                        <div class="card">
                            <div class="card-header bg-primary text-white d-flex justify-content-between p-3">
                                <p class="fw-bold mb-0">${messageDto.userName}</p>
                                <p class="small ms-2 mb-0"><i class="far fa-clock me-1"></i>${messageDto.messageDateTime}</p>
                            </div>
                            <div class="card-body">
                                <p class="mb-0">${messageDto.message}</p>
                           </div>
                        </div>
                        <div>
                            <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-8.webp" alt="avatar"
                                    class="rounded-circle shadow-1-strong ms-1" width="40">
                        </div>
                     </li>`;
    }
    else if (messageDto) {

        liElement = `<li class="chat-left d-flex mb-4">
                        <div>
                            <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-8.webp" alt="avatar"
                                    class="rounded-circle shadow-1-strong me-1" width="40">
                        </div>
                        <div class="card">
                            <div class="card-header bg-info d-flex justify-content-between p-3">
                                <p class="fw-bold mb-0">${messageDto.userName}</p>
                                <p class="small ms-2 mb-0"><i class="far fa-clock me-1"></i>${messageDto.messageDateTime}</p>
                            </div>
                            <div class="card-body">
                                <p class="mb-0">${messageDto.message}</p>
                            </div>
                        </div>
                     </li>`;
    }

    return liElement;
}

function createReceivedContactRequest(contactRequestDto) {

    let divElement = '';

    if (contactRequestDto) {

        divElement = ` <div id="removeReceivedContactRequestCard-${contactRequestDto.senderUserName}" 
                                    class="card mb-3 shadow rounded-3 w-75 m-auto">
                                    <div class="contact-request-card-header bg-primary text-white rounded-3">
                                        <div>
                                            <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-8.webp" alt="avatar"
                                                 class="rounded-circle shadow-1-strong" width="40">
                                            <span class="online-indicator" style="left:42px;"></span>
                                            <strong class="ms-1">${contactRequestDto.senderUserName}</strong>
                                        </div>
                                        <div class="ms-2">
                                            <div class="small">${contactRequestDto.dateTime}</div>
                                        </div>
                                    </div>
                                    <div class="contact-request-card-body rounded-3">
                                        <p class="card-text">${contactRequestDto.contactMessage}</p>
                                        <button id="acceptContactRequest-${contactRequestDto.senderUserName}"
                                                class="modern-button me-2 d-inline-block text-primary">
                                            Accept
                                        </button>
                                        <button id="declineContactRequest-${contactRequestDto.senderUserName}"
                                                class="modern-button me-2 d-inline-block text-danger">
                                            Decline
                                        </button>
                                    </div>
                                </div>`;
    }

    return divElement;
}

function createIssuedContactRequest(contactRequestDto) {

    let divElement = '';

    if (contactRequestDto) {

        divElement = `<div id="removeIssuedContactRequestCard-${contactRequestDto.receiverUserName}" 
                                    class="card mb-3 shadow rounded-3 w-75 m-auto">
                                    <div class="contact-request-card-header bg-primary text-white rounded-3">
                                        <div>
                                            <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-8.webp" alt="avatar"
                                                 class="rounded-circle shadow-1-strong" width="40">
                                            <span class="online-indicator" style="left:42px;"></span>
                                            <strong class="ms-1">${contactRequestDto.receiverUserName}</strong>
                                        </div>
                                        <div class="ms-2">
                                            <div class="small">${contactRequestDto.dateTime}</div>
                                        </div>
                                    </div>
                                    <div class="contact-request-card-body rounded-3">
                                        <p class="card-text">${contactRequestDto.contactMessage}</p>
                                        <button id="removeContactRequest-${contactRequestDto.receiverUserName}"
                                                class="modern-button mt-1 me-2 d-inline-block text-danger">
                                            Remove
                                        </button>
                                    </div>
                                </div>`;
    }

    return divElement;
}

function createGroupMember(chatUser) {

    let divElement = '';

    if (chatUser != null) {

        divElement = `<div id="groupMember-${chatUser.userName}" class="col d-flex align-items-center py-2">
                                <div class="d-flex flex-row">
                                    <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-8.webp" alt="avatar"
                                         class="rounded-circle d-flex align-self-center me-3 shadow-1-strong" width="40">
                                    <div class="d-flex flex-column flex-grow-1">
                                        <p class="fw-bold mb-1 mt-5">${chatUser.userName}</p>
                                        <input id="groupMemberUserId-${chatUser.userName}" type="hidden" value="${chatUser.userId}" />
                                        <div class="d-flex">
                                           <button id="blockGroupMemberBtn-${chatUser.userName}" class="modern-button text-danger me-2">Block</button>
                                           <button id="removeGroupMemberBtn-${chatUser.userName}" class="modern-button text-danger">Remove</button>
                                        </div>
                                    </div>
                                </div>
                            </div>`;
    }

    return divElement;
}

function createBlockMembersButton() {

    return `<div id="groupOptionsBlockedMembers" class="col-3 border-bottom border-primary">
                <p id="blockedGroupMembersBtn" class="group-menu-btn fw-bold text-center">Blocked Members</p>
            </div>`;
}

function createBlockedGroupMember(chatUser) {

    let divElement = '';

    if (chatUser != null) {

        divElement = ` <div id="blockedGroupMember-${chatUser.userName}" class="col d-flex align-items-center py-2">
                            <div class="d-flex flex-row">
                                <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-8.webp" alt="avatar"
                                     class="rounded-circle d-flex align-self-center me-3 shadow-1-strong grayscale" width="40">
                                <div class="d-flex flex-column flex-grow-1">
                                    <p class="fw-bold mb-1 mt-5">${chatUser.userName}</p>
                                    <input id="blockedGroupMemberUserId-${chatUser.userName}" type="hidden" value="${chatUser.userId}" />
                                    <div class="d-flex">
                                        <button id="unblockGroupMemberBtn-${chatUser.userName}" class="modern-button text-primary me-2">Unblock</button>
                                        <button id="removeBlokedGroupMemberBtn-${chatUser.userName}" class="modern-button text-danger">Remove</button>
                                    </div>
                                </div>
                            </div>
                        </div>`;
    }

    return divElement;
}

function showGroupsMenu() {

    document.getElementById('groupsSideMenu').classList.remove('groups-side-menu');

    document.getElementById('contactsSideMenu').classList.add('contacts-side-menu');

    $('#contactsSideMenuModal').modal('hide');
}

function showContactsMenu() {

    document.getElementById('groupsSideMenu').classList.add('groups-side-menu');

    document.getElementById('contactsSideMenu').classList.remove('contacts-side-menu');

    $('#groupsSideMenuModal').modal('hide');
}

function createGroupNotification(notification) {

    let divElement = ` <div class="col-12 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title text-center mb-3">Created Group</h5>
                                <p class="card-text">
                                    Group Name: ${notification.groupName}
                                </p>
                                <p class="text-muted">On: ${notification.dateTime}</p>
                                <a href="#" class="modern-button text-danger">Remove</a>
                            </div>
                        </div>
                    </div>`;

    return divElement;
}

function createIssuedContactRequestNotification(notification) {

    let divElement = `<div class="col-12 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title text-center mb-3">Issued Contact Request</h5>
                                <p class="card-text">
                                    To: ${notification.receiverUserName}
                                </p>
                                <p class="text-muted">On: ${notification.dateTime}</p>
                                <a href="#" class="modern-button text-danger">Remove</a>
                            </div>
                        </div>
                    </div>`;

    return divElement;
}

function createReceivedContactRequestNotification(notification) {

    let divElement = `<div class="col-12 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title text-center mb-3">Received Contact Request</h5>
                                <p class="card-text">
                                   From: ${notification.senderUserName}
                                </p>
                                <p class="text-muted">On: ${notification.dateTime}</p>
                                <a href="#" class="modern-button text-danger">Remove</a>
                            </div>
                        </div>
                     </div>`;

    return divElement;
}

function createAddedGroupMemberNotification(notification) {

    let divElement = `<div class="col-12 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title text-center mb-3">Added Group Member</h5>
                                <p class="card-text">
                                    Group Admin: ${notification.groupAdminUserName} Added New Group Member: ${notification.groupMemberUserName}
                                    In Group: ${notification.groupName}
                                </p>
                                <p class="text-muted">On: ${notification.dateTime}</p>
                                <a href="#" class="modern-button text-danger">Remove</a>
                            </div>
                        </div>
                    </div>`;

    return divElement;
}

function createRemovedGroupMemberNotification(notification) {

    let divElement = ` <div class="col-12 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title text-center mb-3">Removed Group Member</h5>
                                <p class="card-text">
                                    Group Admin: ${notification.groupAdminUserName} Removed Group Member: ${notification.groupMemberUserName}
                                    From Group: ${notification.groupName}
                                </p>
                                <p class="text-muted">On: ${notification.dateTime}</p>
                                <a href="#" class="modern-button text-danger">Remove</a>
                            </div>
                        </div>
                    </div>`;

    return divElement;
}

function createBannedGroupMemberNotification(notification) {

    let divElement = `<div class="col-12 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title text-center mb-3">Banned Group Member</h5>
                                <p class="card-text">
                                    Group Admin: ${notification.groupAdminUserName} Banned Group Member: ${notification.groupMemberUserName}
                                    From Group: ${notification.groupName}
                                </p>
                                <p class="text-muted">On: ${notification.dateTime}</p>
                                <a href="#" class="modern-button text-danger">Remove</a>
                            </div>
                        </div>
                    </div>`;

    return divElement;
}

function createRemovedChatMessageNotification(notification) {

    let divElement = `<div class="col-12 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title text-center mb-3">Removed Chat Message</h5>
                                <p class="card-text">
                                    ${notification.userName} Removed Chat Message
                                </p>
                                <p class="text-muted">On: ${notification.dateTime}</p>
                                <a href="#" class="modern-button text-danger">Remove</a>
                            </div>
                        </div>
                    </div>`;

    return divElement;
}

function createdAcceptedContactRequestNotification(notification) {

    let divElement = ` <div class="col-12 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title text-center mb-3">Accepted Contact Request</h5>
                                <p class="card-text">
                                    From ${notification.senderUserName} To ${notification.receiverUserName}
                                </p>
                                <p class="text-muted">On: ${notification.dateTime}</p>
                                <a href="#" class="modern-button text-danger">Remove</a>
                            </div>
                        </div>
                    </div>`;

    return divElement;
}