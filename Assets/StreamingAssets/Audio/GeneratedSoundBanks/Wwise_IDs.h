/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_EMPTYAUDIOTEST = 520202705U;
        static const AkUniqueID PLAY_FOOTSTEP = 1602358412U;
        static const AkUniqueID PLAY_FRUITGLOW = 520175615U;
        static const AkUniqueID PLAY_GOODORBADFRUIT = 2781998183U;
        static const AkUniqueID PLAY_INGAMEMUSIC = 3799629626U;
        static const AkUniqueID PLAY_MAINMENU = 3738780720U;
        static const AkUniqueID PLAY_NONINGAMEMUSIC = 3584345201U;
        static const AkUniqueID PLAY_PAUSE = 4233560256U;
        static const AkUniqueID PLAY_TESTSOUND = 2752533807U;
        static const AkUniqueID STOP_FRUITGLOW = 3338478285U;
        static const AkUniqueID STOP_INGAMEMUSIC = 1319671012U;
        static const AkUniqueID STOP_MAINMENU = 890527358U;
        static const AkUniqueID STOP_PAUSE = 3298098222U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAMESTATES
        {
            static const AkUniqueID GROUP = 777429653U;

            namespace STATE
            {
                static const AkUniqueID INGAME = 984691642U;
                static const AkUniqueID MAINMENU = 3604647259U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PAUSE = 3092587493U;
            } // namespace STATE
        } // namespace GAMESTATES

        namespace PLAYERSTATES
        {
            static const AkUniqueID GROUP = 4069290704U;

            namespace STATE
            {
                static const AkUniqueID AWAKE = 1151176110U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID OUTOFENERGY = 1274144392U;
                static const AkUniqueID SLEEP = 3671647190U;
            } // namespace STATE
        } // namespace PLAYERSTATES

    } // namespace STATES

    namespace SWITCHES
    {
        namespace ENERGYLEVEL
        {
            static const AkUniqueID GROUP = 2286036297U;

            namespace SWITCH
            {
                static const AkUniqueID HIGHENERGY = 2227543397U;
                static const AkUniqueID LOWENERGY = 1772229705U;
                static const AkUniqueID NORMALENERGY = 3278998676U;
            } // namespace SWITCH
        } // namespace ENERGYLEVEL

        namespace GOODORBADFRUIT
        {
            static const AkUniqueID GROUP = 3201173508U;

            namespace SWITCH
            {
                static const AkUniqueID BADFRUIT = 229773992U;
                static const AkUniqueID GOODFRUIT = 1899661724U;
            } // namespace SWITCH
        } // namespace GOODORBADFRUIT

        namespace GROUNDMATERIAL
        {
            static const AkUniqueID GROUP = 3072116243U;

            namespace SWITCH
            {
                static const AkUniqueID DIRT = 2195636714U;
                static const AkUniqueID GRASS = 4248645337U;
            } // namespace SWITCH
        } // namespace GROUNDMATERIAL

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID ENERGYLEVELRTPC = 1841973268U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID INGAMEMUSIC_SOUNDBANK = 1668970261U;
        static const AkUniqueID NONINGAMEMUSIC_SOUNDBANK = 3695227540U;
        static const AkUniqueID SFX_SOUNDBANK = 2641024368U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
