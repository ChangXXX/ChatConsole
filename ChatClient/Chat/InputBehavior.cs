using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Chat;

public enum InputBehavior
{
    SendAll = 1, // 전체 채팅 보내기
    CreateRoom = 2, // 채팅방 생성
    ActivationRoom = 3, // 채팅방 리스트 get
    JoinManyUserRoom = 4, // 사람 제일 많은 채팅방 입장
    GetUsers = 5 // 유저 리스트 획득
}
