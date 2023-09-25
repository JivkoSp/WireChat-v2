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

function showGroupsMenu() {

    document.getElementById('groupsSideMenu').classList.remove('groups-side-menu');

    document.getElementById('contactsSideMenu').style.display = 'none';

    $('#contactsSideMenuModal').modal('hide');
}