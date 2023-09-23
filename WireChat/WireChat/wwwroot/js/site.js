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

function createChatMessage(messageDto) {

    const liElement = '';

    if (messageDto !== null && messageDto.isFromCurrentUser === true) {

        liElement = `<li class="d-flex justify-content-between mb-4">
                        <div class="card w-100">
                            <div class="card-header d-flex justify-content-between p-3">
                                <p class="fw-bold mb-0">${messageDto.userName}</p>
                                <p class="text-muted small mb-0"><i class="far fa-clock"></i>${messageDto.messageDateTime}</p>
                            </div>
                            <div class="card-body">
                                <p class="mb-0">${messageDto.message}</p>
                            </div>
                        </div>
                        <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-5.webp" alt="avatar"
                            class="rounded-circle d-flex align-self-start ms-3 shadow-1-strong" width="60">
                     </li>`;
    }
    else if (messageDto !== null) {

        liElement = `<li class="d-flex justify-content-between mb-4">
                        <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-6.webp" alt="avatar"
                            class="rounded-circle d-flex align-self-start me-3 shadow-1-strong" width="60">
                        <div class="card">
                            <div class="card-header d-flex justify-content-between p-3">
                                <p class="fw-bold mb-0">${messageDto.userName}</p>
                                <p class="text-muted small mb-0"><i class="far fa-clock"></i>${messageDto.messageDateTime}</p>
                            </div>
                            <div class="card-body">
                                <p class="mb-0">${messageDto.message}</p>
                            </div>
                        </div>
                     </li>`;
    }

    return liElement;
}