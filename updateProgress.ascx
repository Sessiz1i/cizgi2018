<%@ Control Language="C#" AutoEventWireup="true" CodeFile="updateProgress.ascx.cs" Inherits="updateProgress" %>
<!-- Modal Start here-->
<style>
@-webkit-keyframes progress-bar-stripes {
  from {
    background-position: 40px 0;
  }
  to {
    background-position: 0 0;
  }
}
@keyframes progress-bar-stripes {
  from {
    background-position: 40px 0;
  }
  to {
    background-position: 0 0;
  }
}
.progress{
  overflow: hidden;
  margin-bottom: 22px;
  background-color: #f5f5f5;
    height: 35px;
    border-radius: 25px;
    box-shadow: 1px 2px 10px 1px rgba(0, 0, 0, 0.5);
}
    .progress-bar{
        width: 100%;
        font-size: 22px;
        line-height: 37px;
        font-weight: bold;
        background-color: #5cb85c;
          float: left;
          color: #fff;
          text-align: center;
          box-shadow: inset 0 -1px 0 rgba(0, 0, 0, 0.15);
          -webkit-transition: width 0.6s ease;
          transition: width 0.6s ease;
    }
    /* line 54, ../sass/bootstrap/_progress-bars.scss */
    .progress-striped .progress-bar,
    .progress-bar-striped {
      background-image: -webkit-linear-gradient(45deg, rgba(255, 255, 255, 0.15) 25%, transparent 25%, transparent 50%, rgba(255, 255, 255, 0.15) 50%, rgba(255, 255, 255, 0.15) 75%, transparent 75%, transparent);
      background-image: linear-gradient(45deg, rgba(255, 255, 255, 0.15) 25%, transparent 25%, transparent 50%, rgba(255, 255, 255, 0.15) 50%, rgba(255, 255, 255, 0.15) 75%, transparent 75%, transparent);
      background-size: 40px 40px;
    }

    /* line 64, ../sass/bootstrap/_progress-bars.scss */
    .progress.active .progress-bar,
    .progress-bar.active {
      -webkit-animation: progress-bar-stripes .5s linear infinite;
      animation: progress-bar-stripes .5s linear infinite;
    }
    .modal-dialog-centered {
      display: flex;
      align-items: center;
      min-height: calc(100% - 1rem);
    }
    @media (min-width: 576px) {
      .modal-dialog {
        max-width: 500px;
        margin: 1.75rem auto;
      }
      .modal-dialog-centered {
        min-height: calc(100% - 3.5rem);
      }
    }

</style>

<div class="modal show" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style=" overflow-y:visible;">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-body">
      <div class="progress">
                <div class="progress-bar progress-bar-striped active" role="progressbar">
                    <asp:Literal ID="lttLoginTitle8" runat="server" Text="<%$Resources:strings, updateProgresLoader %>"/>
                </div>
            </div>
            </div>
    </div>
</div>
<!-- Modal ends Here -->